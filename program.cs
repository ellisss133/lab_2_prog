using System;
using System.Collections.Generic;

class Document {
  public string Name { get; }
  public string Author { get; }
  public List<string> Keywords { get; }
  public string Topic { get; }
  public string FilePath { get; }

  public Document(string name, string author, List<string> keywords, string topic, string filePath) {
    Name = name;
    Author = author;
    Keywords = keywords;
    Topic = topic;
    FilePath = filePath;
  }

  public virtual void GetInfo() {
    Console.WriteLine($"Название: {Name}, Автор: {Author}, Ключевые слова: {string.Join(", ", Keywords)}, Тематика: {Topic}, Путь: {FilePath}");
  }
}

class WordDocument : Document {
  public int WordCount { get; }

  public WordDocument(string name, string author, List<string> keywords, string topic, string filePath, int wordCount)
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

  public PdfDocument(string name, string author, List<string> keywords, string topic, string filePath, bool isEncrypted)
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

  public ExcelDocument(string name, string author, List<string> keywords, string topic, string filePath, int sheetCount)
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

  public TxtDocument(string name, string author, List<string> keywords, string topic, string filePath, int lineCount)
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

  public HtmlDocument(string name, string author, List<string> keywords, string topic, string filePath, string encoding)
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
    if (_documents.Count == 0) {
      Console.WriteLine("Документов нет.");
      return;
    }

    foreach (var document in _documents) {
      document.GetInfo();
      Console.WriteLine("----------------------");
    }
  }
  
  public void ShowMenu() {
    while (true) {
      Console.WriteLine("\nМеню:");
      Console.WriteLine("1. Добавить документ");
      Console.WriteLine("2. Показать все документы");
      Console.WriteLine("3. Выйти");
      Console.Write("Выберите действие: ");

      string choice = Console.ReadLine();
      switch (choice) {
        case "1":
          AddDocumentFromInput();
          break;
        case "2":
          ShowDocuments();
          break;
        case "3":
          return;
        default:
          Console.WriteLine("Неверный ввод. Попробуйте снова.");
          break;
      }
    }
  }

  private void AddDocumentFromInput() {
    Console.Write("Введите название: ");
    string name = Console.ReadLine();
    
    Console.Write("Введите автора: ");
    string author = Console.ReadLine();
    
    Console.Write("Введите ключевые слова через запятую: ");
    List<string> keywords = new List<string>(Console.ReadLine().Split(','));

    Console.Write("Введите тематику: ");
    string topic = Console.ReadLine();
    
    Console.Write("Введите путь к файлу: ");
    string filePath = Console.ReadLine();
    
    Console.WriteLine("Выберите тип документа:");
    Console.WriteLine("1. Word\n2. PDF\n3. Excel\n4. TXT\n5. HTML");
    string docType = Console.ReadLine();

    switch (docType) {
      case "1":
        Console.Write("Введите количество слов: ");
        int wordCount = int.Parse(Console.ReadLine());
        AddDocument(new WordDocument(name, author, keywords, topic, filePath, wordCount));
        break;
      case "2":
        Console.Write("Документ зашифрован? (true/false): ");
        bool isEncrypted = bool.Parse(Console.ReadLine());
        AddDocument(new PdfDocument(name, author, keywords, topic, filePath, isEncrypted));
        break;
      case "3":
        Console.Write("Введите количество листов: ");
        int sheetCount = int.Parse(Console.ReadLine());
        AddDocument(new ExcelDocument(name, author, keywords, topic, filePath, sheetCount));
        break;
      case "4":
        Console.Write("Введите количество строк: ");
        int lineCount = int.Parse(Console.ReadLine());
        AddDocument(new TxtDocument(name, author, keywords, topic, filePath, lineCount));
        break;
      case "5":
        Console.Write("Введите кодировку: ");
        string encoding = Console.ReadLine();
        AddDocument(new HtmlDocument(name, author, keywords, topic, filePath, encoding));
        break;
      default:
        Console.WriteLine("Неверный ввод.");
        break;
    }
  }
}

class Program {
  static void Main() {
    DocumentManager manager = DocumentManager.Instance;
    manager.ShowMenu();
  }
}
