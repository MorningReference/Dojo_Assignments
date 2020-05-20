from django.db import models
from datetime import date, datetime
from django.utils.dateparse import parse_date
import bcrypt, re

class UserManager(models.Manager):
    def user_registration_validator(self,postData):
        errors = {}

        if len(postData['firstNameReg']) == 0:
            errors['firstNameReg'] = "Your First Name cannot be left empty!"
        elif len(postData['firstNameReg']) < 2:
            errors['firstNameReg'] = "Your First Name needs to be more than 2 characters long!"
        if len(postData['lastNameReg']) == 0:
            errors['lastNameReg'] = "Your Last Name cannot be left empty!"
        elif len(postData['lastNameReg']) < 2:
            errors['lastNameReg'] = "Your Last Name needs to be more than 2 characters long!"
        EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
        if not EMAIL_REGEX.match(postData['emailReg']):     
            errors['emailReg'] = "Invalid email address!"
        elif len(User.objects.filter(email=postData['emailReg'])) > 0:
            errors['emailReg'] = "This email address already exists, please enter another or login!"
        if parse_date(postData['birthdayReg']) > date.today():
            errors['birthdayReg'] = "You must enter a date in the past!"
        elif parse_date(postData['birthdayReg']) >= date(date.today().year - 13, date.today().month, date.today().day):
            errors['birthdayReg'] = "You must be older than 13 to register!"
        if len(postData['passwordReg']) < 8:
            errors['passwordReg'] = "The password needs to be more than 8 characters long!"
        if not (postData['passwordReg'] == postData['confirmPasswordReg']):
            errors['confirmPasswordReg'] = "The password and confirm password fields do not match! Try again."

        return errors

    def user_login_validator(self,postData):
        errors = {}
        user = User.objects.filter(email = postData['emailLogin'])

        EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
        if not EMAIL_REGEX.match(postData['emailLogin']):     
            errors['emailLogin'] = "Invalid email address!"

        if user:
            logged_user = user[0]
            if bcrypt.checkpw(postData['passwordLogin'].encode(), logged_user.password.encode()) == False:
                errors['passwordLogin'] = "This password is incorrect!"
        else:
            errors['passwordLogin'] = "This password is incorrect!"

        return errors


class User(models.Model):
    first_name = models.CharField(max_length = 255)
    last_name = models.CharField(max_length = 255)
    email = models.EmailField(max_length = 254)
    birth_date = models.DateField()
    password = models.CharField(max_length = 255)
    confirm_password = models.CharField(max_length = 255)


    objects = UserManager()


