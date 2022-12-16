using System.Collections.Generic;

public class Medium
{
    public string Name { get; set; }
    public List<Photo> Photos { get; set; }
    public string FilePath { get; set; }
}

public class Photo
{
    public string Path { get; set; }
    public string Name { get; set; }
}

public class Root
{
    public List<TranslatedContent> TranslatedContents { get; set; }
}

public class Topic
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int TopicId { get; set; }
    public List<Medium> Media { get; set; }
}

public class TranslatedContent
{
    public int LanguageId { get; set; }
    public string LanguageName { get; set; }
    public List<Topic> Topics { get; set; }
}