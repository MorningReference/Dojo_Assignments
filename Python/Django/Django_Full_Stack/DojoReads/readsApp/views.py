from django.shortcuts import render, redirect
from django.contrib import messages
from .models import *

def index(request):
    if 'user_id' not in request.session:
        return redirect('/')
    user = User.objects.filter(id = request.session['user_id'])[0]
    context = {
        'user': user,
        'all_books_with_reviews': Book.objects.filter(reviews__isnull = False).distinct(),
        # 'recent_book_reviews': Book.objects.filter(reviews__user_reviewed = user).order_by('-created_at').distinct()[:3],
        'recent_book_reviews': Review.objects.filter(user_reviewed = user).order_by('-created_at').distinct()[:3],
        'all_the_books': Book.objects.all(),
    }
    return render(request, 'bookindex.html', context)

def newBook(request):
    if 'user_id' not in request.session:
        return redirect('/')
    context = {
        'all_the_authors': Author.objects.all().distinct(),
    }
    return render(request, 'newBook.html', context)

def createBook(request):
    if 'user_id' not in request.session:
        return redirect('/')

    if request.method == "GET":
        return redirect('/books')
    book = Book.objects.filter(title = request.POST['book-title'])
    

    errors = Book.objects.book_validator(request.POST)
    
    if len(errors) > 0:
        for key, value in errors.items():
            messages.error(request, value, extra_tags=key)
        return redirect('/books/add')
    
    if not request.POST['book-author']:
        if len(book) == 0:
            new_book = Book.objects.create(
            title = request.POST['book-title'],
            author = Author.objects.filter(name = request.POST['select-author'])[0]
        )
        else:
            author = Author.objects.filter(name = request.POST['select-author'])[0]
            author.books.add(new_book)

    else:
        new_author = Author.objects.create(
            name = request.POST['book-author']
        )
        if len(book) == 0:
            new_book = Book.objects.create(
                title = request.POST['book-title'],
                author = new_author
            )
        print("book-author")

    print("this is running")
    Review.objects.create(
        desc = request.POST['book-review'],
        rating = request.POST['select-rating'],
        user_reviewed = User.objects.filter(id = request.session['user_id'])[0],
        book_reviewed = new_book
    )
    return redirect(f'/books/{new_book.id}')

def showBook(request, bookId):
    if 'user_id' not in request.session:
        return redirect('/')
    current_book = Book.objects.filter(id = bookId)[0]
    context = {
        'book': current_book,
        'all_the_reviews': Review.objects.filter(book_reviewed = current_book).all(),
    }
    return render(request, 'showBook.html', context)

def createReview(request, bookId):
    if 'user_id' not in request.session:
        return redirect('/')

    if request.method == "GET":
        return redirect('/books')
    
    errors = Book.objects.review_validator(request.POST)
    
    if len(errors) > 0:
        for key, value in errors.items():
            messages.error(request, value, extra_tags=key)
        return redirect(f'/books/{bookId}')

    Review.objects.create(
        desc = request.POST['review-desc'],
        rating = request.POST['book-rating'],
        user_reviewed = User.objects.filter(id = request.session['user_id'])[0],
        book_reviewed = Book.objects.filter(id = bookId)[0]
    )
    return redirect(f'/books/{bookId}')

def deleteReview(request, bookId, reviewId):
    if 'user_id' not in request.session:
        return redirect('/')
    
    # if request.method == "GET":
    #     return redirect(f'/books/{bookId}')
    
    review = Review.objects.filter(id = reviewId)[0]
    if review.user_reviewed.id != request.session['user_id']:
        return redirect(f'/books/{bookId}')

    review.delete()
    return redirect(f'/books/{bookId}')
