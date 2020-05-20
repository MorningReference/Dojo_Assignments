from django.db import models
from login_registration_app.models import User

class BookManager(models.Manager):
    def book_validation(self, postData):
        errors = {}
        if len(postData['book_title']) == 0:
            errors['book_title'] = "The title is required, please enter a title!"
            print('Contains no title')
        if len(postData['book_desc']) < 5:
            errors['book_desc'] = "The description of the book must be at least 5 characters long!"
        return errors



class Book(models.Model):
    title = models.CharField(max_length = 255)
    desc = models.TextField()
    uploaded_by = models.ForeignKey(User, related_name ="books_uploaded", on_delete = models.CASCADE)
    users_who_like = models.ManyToManyField(User, related_name = "liked_books")
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)

    objects = BookManager()