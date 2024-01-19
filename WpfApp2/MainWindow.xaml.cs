using booooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace booooks
{
    // Класс, представляющий книгу
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }

        public override string ToString()
        {
            return $"Название: {Title} Автор: {Author} Год: ({Year}), Жанр: {Genre}";
        }
    }

    // Класс, представляющий книжный магазин
    public class Bookstore
    {
        private List<Book> books = new List<Book>();

        // Метод для добавления новой книги в магазин
        public void AddBook(Book book)
        {
            books.Add(book);
        }

        // Метод для вывода списка всех книг в магазине
        public List<Book> GetAllBooks()
        {
            return books;
        }
    }

    public partial class MainWindow : Window
    {
        private Bookstore bookstore = new Bookstore();

        public MainWindow()
        {
            InitializeComponent();
            booksListBox.ItemsSource = bookstore.GetAllBooks();
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            // Добавляем новую книгу при нажатии кнопки
            Book newBook = new Book
            {
                Title = titleTextBox.Text,
                Author = authorTextBox.Text,
                Year = int.Parse(yearTextBox.Text),
                Genre = genreTextBox.Text
            };

            bookstore.AddBook(newBook);

            // Обновляем список книг в ListBox
            booksListBox.ItemsSource = null;
            booksListBox.ItemsSource = bookstore.GetAllBooks();

            // Очищаем поля ввода
            titleTextBox.Clear();
            authorTextBox.Clear();
            yearTextBox.Clear();
            genreTextBox.Clear();
        }
    }
}
