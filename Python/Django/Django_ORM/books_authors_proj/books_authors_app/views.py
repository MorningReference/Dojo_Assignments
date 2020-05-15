from django.shortcuts import render, redirect
from .models import Book, Author

def create_books(request):
    context = {
        'all_the_books': Book.objects.all()
    }
    return render(request, 'books.html', context)

def create_authors(request):
    context = {
        'all_the_authors': Author.objects.all()
    }
    return render(request, 'authors.html', context)

def process_book(request):
    Book.objects.create(
        title = request.POST['book-title'],
        desc = request.POST['book-description']
    )
    return redirect('/')

def process_author(request):
    Author.objects.create(
        first_name = request.POST['author-first-name'],
        last_name = request.POST['author-last-name'],
        notes = request.POST['author-notes']
    )
    return redirect('/authors')

def display_book(request, book_id):
    context = {
        'book': Book.objects.get(id=book_id),
        'all_the_authors': Author.objects.exclude(books__id = book_id)
    }
    return render(request, 'displayBook.html', context)

def display_author(request, author_id):
    context = {
        'author': Author.objects.get(id=author_id),
        'all_the_books': Book.objects.exclude(author__id = author_id)
    }
    return render(request, 'displayAuthor.html', context)

def add_author(request, book_id):
    Book.objects.get(id=book_id).author.add(Author.objects.get(id=request.POST['author-to-add']))
    return redirect('/books/'+ book_id)

def add_book(request, author_id):
    Author.objects.get(id=author_id).books.add(Book.objects.get(id=request.POST['book-to-add']))
    return redirect('/authors/'+ author_id)

