from django.db import models
from datetime import date
from django.utils.dateparse import parse_date
import re

class UserManager(models.Manager):
    def registration_validation(self, postData):
        EMAIL_REGEX = re.compile(r'^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$')
        errors = {}

        #First name validation
        if len(postData['name']) == 0:
            errors['name'] = "This field cannot be left empty!"
        elif len(postData['name']) < 2:
            errors['name'] = "The first name has to be more than 2 characters long!"
        elif len(postData['name']) > 30:
            erorrs['name'] = "The first name cannot be more than 30 characters long!"
            
        #Alias validation
        user = User.objects.filter(alias = postData['alias'])
        if len(postData['alias']) == 0:
            errors['alias'] = "This field cannot be left empty!"
        if user:
            errors['alias'] = "Alias already registered! Please use another alias."

        
        #Email validation
        user = User.objects.filter(email = postData['email'])
        if len(postData['email']) == 0:
            errors['email'] = "This field cannot be left empty!"
        elif len(postData['email']) < 6:
            errors['email'] = "Invalid email address!"
        elif not EMAIL_REGEX.match(postData['email']):
            errors['email'] = "Invalid email address!"
        elif user:
            errors['email'] = "Email already registered! Please use another email address."

        #Birthdate validation
        if len(postData['birthdate']) == 0:
            errors['birthdate'] = "You must enter a valid date!"
        elif parse_date(postData['birthdate']) > date.today():
            errors['birthdate'] = "You must enter a date in the past!"
        elif parse_date(postData['birthdate']) >= date(date.today().year - 13, date.today().month, date.today().day):
            errors['birthdate'] = "You must be older than 13 to register!"

        #Password validation
        if len(postData['password']) == 0:
            errors['password'] = "This field cannot be left empty!"
        elif len(postData['password']) < 8:
            errors['password'] = "The password must be a minimum of 8 characters!"
        elif not PW_REGEX.match(postData['password']):
            errors['password'] = "Password must contain a minimum of 1 uppercase, 1 lowercase, 1 number, and 1 special character!"
        elif postData['password'] != postData['pw_confirm']:
            errors['password'] = "Passwords do not match!"

        return errors


class User(models.Model):
    name = models.CharField(max_length = 30)
    alias = models.CharField(max_length = 30)

    email = models.CharField(max_length = 50)
    birthdate = models.DateField()
    password = models.CharField(max_length = 200)

    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)

    objects = UserManager()