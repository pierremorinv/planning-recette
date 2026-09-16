# Mise en Place

> Je planifie mes repas de la semaine, l'app me sort ma liste de courses.

## Le problème

Je cuisine tous les jours et je planifie déjà mes menus à l'avance. La traduction
« menus » → « liste de courses » se fait à la main : j'additionne mentalement les
quantités de plusieurs recettes, avec des unités qui ne se ressemblent pas
(200 g ici, 0,3 kg là, 2 cuillères ailleurs), et j'oublie systématiquement
quelque chose.

## Ce que fait l'application (V1)

- **Recettes** — créer et enregistrer des recettes : ingrédients, quantités, unités
- **Planning** — poser des repas sur un calendrier : date, créneau, nombre de convives
- **Liste de courses** — générer la liste agrégée pour une recette, un jour ou une semaine
- **Placard** — marquer les ingrédients qu'on a toujours (épices, huile, condiments)
  pour les exclure automatiquement de la liste

## Le cœur technique

L'intérêt du projet n'est pas le CRUD, c'est le **moteur d'agrégation** :

- **Recettes imbriquées** — une sauce maison est une recette réutilisée dans
  plusieurs plats. Le calcul est un parcours récursif du graphe, avec détection
  de cycles (une recette ne peut pas se contenir elle-même).
- **Mise à l'échelle** — une recette prévue pour 4 portions, servie à 6 convives.
- **Conversion d'unités** — et c'est là que c'est piégeux : la conversion
  volume → masse dépend de l'**ingrédient**, pas seulement des unités.
  1 L de lait = 1,03 kg, 1 L de farine = 0,55 kg, 1 oignon ≈ 150 g.
- **Agrégation inter-recettes** — 200 g + 0,3 kg + 2 c. à soupe de farine
  doivent finir en une seule ligne de courses.

## Modèle de données

| Entité | Rôle | Champs principaux |
|---|---|---|
| `Ingredient` | Le référentiel | Nom, UniteDeReference, Densite?, PoidsMoyenPiece?, EstAuPlacard, Rayon |
| `Recette` | Un plat ou une préparation | Nom, NombreDePortions, Preparation? |
| `LigneDeRecette` | Le contenu d'une recette | RecetteId, Quantite, Unite, → Ingredient **ou** sous-recette |
| `Repas` | Un créneau planifié | Date, Creneau, NombreDeConvives |
| `RepasRecette` | Les plats d'un repas | RepasId, RecetteId |
| `LigneDeCourse` | Le résultat du calcul | IngredientId, QuantiteTotale, Unite, EstCoche |

`LigneDeRecette` est la table centrale : c'est elle que lit le moteur de génération.

## Décisions d'architecture

**Pas de table `Jour` ni `Semaine`.** Un jour n'a aucun attribut propre — c'est une
position dans le calendrier, pas un concept métier. Une colonne `Date` sur `Repas`
suffit : la vue jour, semaine ou mois devient la même requête avec des bornes
différentes. On ne modélise pas le calendrier.

**Le planning n'est pas stocké, il est affiché.** La base ne contient que des repas
datés. La grille est dessinée par le composant pour une plage de dates donnée.
Une case vide, c'est l'absence de ligne — pas une ligne vide.

**Le placard n'est pas une entité, c'est une vue.** C'est la liste des ingrédients
marqués `EstAuPlacard`, filtrée par rayon. Un booléen plutôt qu'un inventaire
quantifié : un stock qu'il faut tenir à jour tous les jours finit par mentir, et
un stock qui ment est pire que pas de stock.

**Une ligne de courses porte un ingrédient, pas une recette.** Les recettes sont
l'entrée du calcul, la ligne de courses en est la sortie. On ne fait pas ses
courses en recettes.

**Le nombre de convives est sur le repas.** Lundi midi je mange seul, dimanche soir
nous sommes huit.

**API et front séparés.** Le back expose une API Minimal API, le front est une
application Angular autonome. Le moteur de calcul vit côté back : il détient la
logique, le front affiche et saisit.

**Le moteur est développé et testé sans base de données ni interface.** Une
bibliothèque de classes + xUnit d'abord ; EF Core, API et front ensuite. Le cœur du
produit se valide en deux secondes au lieu de passer par un écran.

## Décisions encore ouvertes

- Comment modéliser le « ou » de `LigneDeRecette` (ingrédient **ou** sous-recette)
- Liste de courses : stockée en base ou recalculée à l'affichage ?
- Tags génériques ou enums typés pour la classification des ingrédients
- Découpage des endpoints Minimal API — un fichier par ressource, regroupés par
  `MapGroup`. À trancher quand le moteur existera, pas avant.

## Stack

- **Back** — .NET 10, Minimal APIs, EF Core
- **Front** — Angular
- **Tests** — xUnit

Projet personnel : construit pour mon usage quotidien avant tout.

## Hors périmètre V1

Voir [BACKLOG.md](BACKLOG.md). Le périmètre a été volontairement réduit au plus
petit parcours complet : *je planifie ma semaine → l'app génère ma liste → je coche
au magasin*. Tout ce qui enrichit ce parcours sans le définir attend.
