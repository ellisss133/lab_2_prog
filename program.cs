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

class DocumentManager {
  private static DocumentManager s_instance;
  private List<Document> _documents = new List<Document>();

  private DocumentManager() { }

  public static DocumentManager Instance {
    get {
      if (s_instance == null) {
        s_instance = new DocumentManager();
      }
      return s_instance;
    }
  }

  public void AddDocument(Document document) {
    _documents.Add(document);
  }

  public void ShowDocuments() {
    foreach (var document in _documents) {
      document.GetInfo();
      Console.WriteLine("----------------------");
    }
  }
}

class Program {
  static void Main() {
    DocumentManager manager = DocumentManager.Instance;

    manager.AddDocument(new WordDocument("Доклад", "Иванов", "наука, доклад", "Образование", "C:/docs/report.docx", 1200));
    manager.AddDocument(new PdfDocument("Учебник", "Петров", "математика, учебник", "Образование", "C:/docs/math.pdf", true));
    manager.AddDocument(new ExcelDocument("Таблица", "Сидоров", "финансы, таблица", "Бизнес", "C:/docs/finance.xlsx", 5));
    manager.AddDocument(new TxtDocument("Заметки", "Смирнов", "личное, заметки", "Личное", "C:/docs/notes.txt", 200));
    manager.AddDocument(new HtmlDocument("Сайт", "Козлов", "веб, сайт", "IT", "C:/docs/index.html", "UTF-8"));

    manager.ShowDocuments();
    Console.ReadLine();
  }
}

