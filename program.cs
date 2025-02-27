using System;
class Document {
  public string Name { get; }
  public string Author { get; }
  public string Keywords { get; }
  public string Topic { get; }
  public string FilePath { get; }

  public Document(string name, string author, string keywords, string topic, string filePath) {
    Name = name;
    Author = author;
    Keywords = keywords;
    Topic = topic;
    FilePath = filePath;
  }

  public virtual void GetInfo() {
    Console.WriteLine($"Название: {Name}, Автор: {Author}, Ключевые слова: {Keywords}, Тематика: {Topic}, Путь: {FilePath}");
  }
}
