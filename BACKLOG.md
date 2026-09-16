# Backlog — Mise en Place

Tout ce qui est hors périmètre V1. Rien n'est abandonné, tout est séquencé.

**Règle :** une idée qui arrive pendant le développement va ici, pas dans le code.

---

## V1 — le périmètre en cours

| Item | Statut |
|---|---|
| Référentiel d'ingrédients (CRUD, rayon, placard) | À faire |
| Recettes avec lignes (quantité + unité) | À faire |
| Moteur : conversion d'unités | À faire |
| Moteur : mise à l'échelle par convives | À faire |
| Moteur : agrégation inter-recettes | À faire |
| Moteur : sous-recettes + détection de cycles | À faire |
| Planning : grille cliquable (ajout d'une recette sur une case) | À faire |
| Génération de la liste de courses (recette / jour / semaine) | À faire |
| Liste de courses cochable | À faire |
| Écran placard (vue filtrée sur les ingrédients) | À faire |

---

## V2 — confort d'usage

Ce qui décidera si l'app est utilisée sur la durée.

| Item | Pourquoi reporté | Note |
|---|---|---|
| **Duplication** (plat / jour / semaine) | Pas bloquant pour un premier usage | ⚠️ À faire tôt : sans ça, ressaisir le petit-déj 7×/semaine tue l'app. Une seule opération : « copier cette sélection et la décaler de N jours ». On copie les **repas**, jamais les recettes. |
| Semaine type réutilisable | Dépend de la duplication | C'est ce jour-là que `Semaine` mérite enfin d'être une entité (elle porte un nom, un drapeau « modèle ») |
| Drag & drop sur le planning | Coûteux en temps, n'ajoute rien au moteur | Angular CDK (`@angular/cdk/drag-drop`) fait le gros du travail — nettement moins coûteux qu'à la main. Trancher avant : la carte représente un **repas** ou un **plat** ? |
| Valeur par défaut du nombre de convives | Détail | Sinon chaque dépôt pose une question et le drag & drop devient pénible |
| Étapes de préparation dans la recette | Pas nécessaire pour générer une liste | Champ déjà prévu, non exploité |

---

## V3 — mobile (reporté, pas un sujet à ce stade)

| Item | Pourquoi reporté | Note |
|---|---|---|
| PWA installable | Pas un sujet à ce stade | Donne « desktop + mobile » avec une seule base de code |
| Mode hors ligne | Écarté pour l'instant — les courses se font en direct, pas besoin | À rouvrir seulement si l'usage change |
| Écran courses dédié mobile | — | Gros caractères, grosses cases à cocher, zéro drag & drop |

---

## V4 — la casquette de chef

Le moteur est le même, seule la façade change.

| Item | Note |
|---|---|
| Produits et conditionnements | Un ingrédient a plusieurs produits (« farine T55 » → « paquet de 1 kg à 1,20 € »). Débloque le mode supermarché : au marché on demande 250 g, au supermarché on achète une plaquette |
| Mode marché / supermarché | Besoin brut vs arrondi au conditionnement |
| Coût matière / food cost | Coût portion, coefficient multiplicateur, marge brute |
| Rendement net vs brut | 1 kg de carottes brutes ≈ 800 g nettes |
| Allergènes | Propagés automatiquement depuis les ingrédients, y compris à travers les sous-recettes |
| Fiche technique imprimable | Le document de travail du chef |

---

## V5 — social

| Item | Pourquoi reporté | Note |
|---|---|---|
| Partage d'une recette par lien | C'est une **dimension**, pas une fonctionnalité : ça traverse tout le modèle | Version pas chère : un jeton dans l'URL + une page en lecture seule. Pas de compte pour le destinataire, pas de droits à gérer |
| Comptes et authentification | — | Prérequis de tout le reste de cette section |
| Partage d'un menu (jour / semaine) | — | Même question qu'à la duplication : le destinataire copie ou référence ? |
| Commentaires, likes | — | L'idée d'origine du « blog de recettes ». Surcouche, jamais le sujet |
| Photos de plats | Pas nécessaires : une fiche technique n'a pas de photo | Si besoin un jour : Unsplash / Pexels, licences claires |

---

## Écarté volontairement

| Item | Pourquoi |
|---|---|
| Placard quantifié (stock avec quantités) | Il faut le décrémenter à chaque repas. Deux oublis et il ment — un stock qui ment est pire que pas de stock. La checklist au moment de générer la liste couvre le besoin pour zéro entretien |
| Stock déduit automatiquement (courses +, repas −) | Élégant sur le papier, mais la vraie vie dérive (repas dehors, grignotage, invités). La dérive est invisible, donc pire |
| HACCP, OCR de factures, gestion fournisseurs | Périmètre des logiciels pro du marché. Une équipe y a passé des années. Réduction de périmètre assumée |
| Application MAUI native | Une PWA donne desktop + mobile avec une seule base de code |
