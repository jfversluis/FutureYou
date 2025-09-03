namespace FutureYouTracker.Models;

public enum TargetCategory
{
    Health,
    Career,
    Learning,
    Personal,
    Finance,
    Relationships,
    Creativity,
    Spiritual,
    Travel,
    Other
}

public static class TargetCategoryExtensions
{
    public static string GetDisplayName(this TargetCategory category)
    {
        return category switch
        {
            TargetCategory.Health => "🏥 Health & Fitness",
            TargetCategory.Career => "💼 Career & Professional",
            TargetCategory.Learning => "📚 Learning & Education",
            TargetCategory.Personal => "🌟 Personal Development",
            TargetCategory.Finance => "💰 Financial Goals",
            TargetCategory.Relationships => "❤️ Relationships & Social",
            TargetCategory.Creativity => "🎨 Creative & Artistic",
            TargetCategory.Spiritual => "🧘 Spiritual & Mindfulness",
            TargetCategory.Travel => "✈️ Travel & Adventure",
            TargetCategory.Other => "📋 Other",
            _ => category.ToString()
        };
    }

    public static string GetIcon(this TargetCategory category)
    {
        return category switch
        {
            TargetCategory.Health => "🏥",
            TargetCategory.Career => "💼",
            TargetCategory.Learning => "📚",
            TargetCategory.Personal => "🌟",
            TargetCategory.Finance => "💰",
            TargetCategory.Relationships => "❤️",
            TargetCategory.Creativity => "🎨",
            TargetCategory.Spiritual => "🧘",
            TargetCategory.Travel => "✈️",
            TargetCategory.Other => "📋",
            _ => "📋"
        };
    }
}