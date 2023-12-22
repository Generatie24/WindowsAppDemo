using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsAppDemo.Models;

namespace WindowsAppDemo
{
    public partial class Form1 : Form
    {
        List<Book> Freshbooks = Database.PopulateBooks();
        
        public Form1()
        {
            
            InitializeComponent();
        }

        private void btnLoadBooks_Click(object sender, EventArgs e)
        {
            List<Book> books = Database.PopulateBooks();
            lstBooks.DataSource = books;
        }

        private void lstBooks_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Book selectedbook = (Book)lstBooks.SelectedItem;
            txtTitle.Text = selectedbook.Title;
            txtAuthor.Text = selectedbook.Author;
            txtYearPublished.Text = selectedbook.YearPublished.ToString();
            txtGenre.Text = selectedbook.Genre;
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.Title = txtTitle.Text;
            book.Author = txtAuthor.Text;
            book.YearPublished = int.Parse(txtYearPublished.Text);
            book.Genre = txtGenre.Text;
            

            lstBooks.DataSource = null;
            List<Book> books = Database.PopulateBooks();
            Database.Books.Add(book);
            lstBooks.DataSource = books;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Book selectedbook = (Book)lstBooks.SelectedItem;
            lstBooks.DataSource = null;
            Freshbooks.Remove(selectedbook);
            
            lstBooks.DataSource = Freshbooks;





        }
    }
}
