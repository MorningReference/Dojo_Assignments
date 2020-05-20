from django.shortcuts import render, redirect
from login_registration_app.models import User
from .models import Book
from django.contrib import messages

def book(request):
    if 'userId' not in request.session:
        return redirect('/')
    elif 'userId' in request.session:
        context = {
            'user': User.objects.get(id = request.session['userId']),
            'all_the_books': Book.objects.all()
        }
        return render(request, 'book.html', context)

def addBook(request):
    errors = Book.objects.book_validation(request.POST)

    if len(errors) > 0:
        for key, value in errors.items():
            messages.error(request, value, extra_tags = key)
        print('this ran')
        return redirect('/books')
    else:
        book = Book.objects.create(
            title = request.POST['book_title'],
            desc = request.POST['book_desc'],
            uploaded_by = User.objects.get(id = request.session['userId']),
        )
        book.users_who_like.add(User.objects.get(id = request.session['userId']))
        return redirect('/books')

def displayBook(request, bookId):
    listOfBooksUploaded = User.objects.get(id = request.session['userId']).books_uploaded.all()
    bookToSearch = Book.objects.get(id = bookId)
    context = {
        'userName': User.objects.get(id = request.session['userId']).first_name,
        'users_who_like_book': Book.objects.get(id = bookId).users_who_like.all(),
        'book': bookToSearch
    }
    if  bookToSearch in listOfBooksUploaded:
        return render(request, 'editBook.html', context)
    elif bookToSearch not in listOfBooksUploaded:
        return render(request, 'displayBook.html', context)

def editBook(request, bookId):
    errors = Book.objects.update_validation(request.POST)

    if len(errors) > 0:
        for key, value in errors.items():
            messages.error(request, value, extra_tags = key)
        print('this ran')
        return redirect(f'/books/{bookId}')

    book = Book.objects.get(id = bookId)
    book.title = request.POST['updated_title']
    book.desc = request.POST['updated_desc']
    book.save()
    return redirect('/books')

def likeBook(request, bookId):
    Book.objects.get(id = bookId).users_who_like.add(User.object.get(id = request.session['userId']))
    return redirect('/books')

def unlikeBook(request, bookId):
    Book.objects.get(id = bookId).users_who_like.remove(User.object.get(id = request.session['userId']))
    return redirect('/books')


def deleteBook(request, bookId):
    Book.objects.get(id = bookId).delete()
    return redirect('/books')

def favoriteBooks(request):
    context ={
        'user': User.objects.get(id = request.session['userId']),
        'favorite_books': User.objects.get(id = request.session['userId']).liked_books.all()
    }
    return render(request, 'favBooks.html', context)

def logout(request):
    request.session.flush()
    return redirect('/')