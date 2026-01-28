# Démonstration CodeRabbit - Service de Calcul de Remise

## 🎯 Contexte

> Le contexte est un service C# qui calcule une remise commerciale en fonction du type de client et du montant de la commande.

Ce projet illustre l'utilisation de **CodeRabbit**, un outil d'analyse automatique de code, dans le cadre d'une Pull Request GitHub.

---

## 📄 Code de démonstration

### Version initiale (avec défauts volontaires)

**Fichier : `DiscountService.cs`**

```csharp
public class DiscountService
{
    public double Calc(double amount, string type)
    {
        if (type == "VIP")
        {
            if (amount > 1000)
            {
                return amount * 0.2;
            }
            else
            {
                return amount * 0.1;
            }
        }
        else
        {
            if (amount > 500)
            {
                return amount * 0.05;
            }
        }

        return 0;
    }
}
```

### ⚠️ Problèmes intentionnels

| Problème | Description |
|----------|-------------|
| Nom de méthode peu clair | `Calc` au lieu d'un nom descriptif |
| Chaînes en dur | `"VIP"` directement dans le code |
| Logique imbriquée | `if` dans `if` complexifie la lecture |
| Pas de validation | Aucune vérification des paramètres |
| Type `double` | Inadapté pour les calculs monétaires |

---

## 🔍 Exemples de commentaires CodeRabbit

| Suggestion | Explication |
|------------|-------------|
| *"The method name Calc is ambiguous"* | Renommer pour améliorer la lisibilité |
| *"Avoid hard-coded string values"* | Utiliser un `enum` pour la maintenance |
| *"Nested conditional statements could be simplified"* | Simplifier la logique métier |
| *"Using double for monetary values may cause precision issues"* | Problème potentiel de précision |

---

## ✅ Version améliorée (après revue)

```csharp
public enum ClientType
{
    Standard,
    Vip
}

public class DiscountService
{
    public decimal CalculateDiscount(decimal amount, ClientType clientType)
    {
        if (amount <= 0)
        {
            return 0;
        }

        return clientType switch
        {
            ClientType.Vip when amount > 1000 => amount * 0.20m,
            ClientType.Vip => amount * 0.10m,
            ClientType.Standard when amount > 500 => amount * 0.05m,
            _ => 0
        };
    }
}
```

---

## ❓ Questions fréquentes

| Question | Réponse |
|----------|---------|
| Pourquoi `decimal` ? | Plus adapté aux calculs financiers |
| CodeRabbit a-t-il écrit ce code ? | Non, il a seulement suggéré des améliorations |
| Peut-on refuser ses suggestions ? | Oui, elles restent facultatives |

---

## 📝 Points clés à retenir

- ✅ Contexte clair et réaliste
- ✅ Code volontairement améliorable
- ✅ CodeRabbit = assistant de revue de code
- ✅ Validation humaine obligatoire
