from django.db import models
from loginApp.models import *

class BookManager(models.Manager):
    def book_validator(self, postData):
        errors = {}

        if len(postData['book-title']) == 0:
            errors['book-title'] = "The title must be filled out!"
        elif len(postData['book-title']) < 2:
            errors['book-title'] = "Please enter a title longer than 2 characters."
        elif len(postData['book-title']) > 60:
            errors['book-title'] = "Please enter a title shorter than 60 characters."

        if not postData['select-author'] and not postData['book-author']:
            errors['book-author'] = "Please select an author from the list or add a new author."
        elif len(postData['book-author']) > 60:
            errors['book-author'] = "Please enter a title shorter than 60 characters."

        if len(postData['book-review']) < 8 and len(postData['book-review']) > 0:
            errors['book-review'] = "Please either have the review be longer than 8 characters or leave it blank."

        return errors

    def review_validator(self, postData):
        errors = {}

        if len(postData['review-desc']) < 8 and len(postData['review-desc']) > 0:
            errors['review-desc'] = "Please either have the review be longer than 8 characters or leave it blank."
        return errors

class Author(models.Model):
    name = models.CharField(max_length = 60)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)

class Book(models.Model):
    title = models.CharField(max_length = 60)
    author = models.ForeignKey(Author, related_name = "books", on_delete = models.CASCADE)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)

    objects = BookManager()

class Review(models.Model):
    desc = models.TextField()
    rating = models.PositiveIntegerField()
    user_reviewed = models.ForeignKey(User, related_name = "reviews", on_delete = models.CASCADE)
    book_reviewed = models.ForeignKey(Book, related_name = "reviews", on_delete = models.CASCADE)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)

    objects = BookManager()