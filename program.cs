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

class WordDocument : Document {
  public int WordCount { get; }

  public WordDocument(string name, string author, string keywords, string topic, string filePath, int wordCount)
    : base(name, author, keywords, topic, filePath) {
    WordCount = wordCount;
  }

  public override void GetInfo() {
    base.GetInfo();
    Console.WriteLine($"Количество слов: {WordCount}");
  }
}

class PdfDocument : Document {
  public bool IsEncrypted { get; }

  public PdfDocument(string name, string author, string keywords, string topic, string filePath, bool isEncrypted)
    : base(name, author, keywords, topic, filePath) {
    IsEncrypted = isEncrypted;
  }

  public override void GetInfo() {
    base.GetInfo();
    Console.WriteLine($"Зашифрован: {IsEncrypted}");
  }
}

class ExcelDocument : Document {
  public int SheetCount { get; }

  public ExcelDocument(string name, string author, string keywords, string topic, string filePath, int sheetCount)
    : base(name, author, keywords, topic, filePath) {
    SheetCount = sheetCount;
  }

  public override void GetInfo() {
    base.GetInfo();
    Console.WriteLine($"Количество листов: {SheetCount}");
  }
}

class TxtDocument : Document {
  public int LineCount { get; }

  public TxtDocument(string name, string author, string keywords, string topic, string filePath, int lineCount)
    : base(name, author, keywords, topic, filePath) {
    LineCount = lineCount;
  }

  public override void GetInfo() {
    base.GetInfo();
    Console.WriteLine($"Количество строк: {LineCount}");
  }
}

class HtmlDocument : Document {
  public string Encoding { get; }

  public HtmlDocument(string name, string author, string keywords, string topic, string filePath, string encoding)
    : base(name, author, keywords, topic, filePath) {
    Encoding = encoding;
  }

  public override void GetInfo() {
    base.GetInfo();
    Console.WriteLine($"Кодировка: {Encoding}");
  }
}
