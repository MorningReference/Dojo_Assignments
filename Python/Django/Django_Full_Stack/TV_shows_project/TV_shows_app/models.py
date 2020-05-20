from django.db import models
from datetime import date, datetime
from django.utils.dateparse import parse_date

class ShowManager(models.Manager):
    def add_show_validator(self, postData):
        print("in validator function")
        print("form data", postData)

        errors = {}
        if len(postData["show_title"]) == 0:
            errors["show_title"] = "The title of the Show cannot be left empty!"
        elif len(postData['show_title']) < 2:
            errors["show_title"] = "The title should be at least 2 characters long!"
        # elif len(Show.objects.filter(title=postData['show_title'])) > 0 :
        #     errors['show_title'] = "You cannot create a duplicate entry with this information."
        if len(postData['show_network']) < 3:
            errors["show_network"] = "The network name should be at least 3 characters long!"
        if len(postData['show_desc']) > 0 and len(postData['desc']) < 10:
            errors["show_desc"] = "The description should be at least 10 characters long, if a description is to be entered!"
        if parse_date(postData['show_release_date']) > date.today():
            errors['show_release_date'] = "Must enter a past date for the release date!"
        return errors

    def edit_show_validator(self,postData):
        print("in validator function")
        print("form data", postData)

        errors = {}
        if len(postData["updated_title"]) == 0:
            errors["updated_title"] = "The title of the Show cannot be left empty!"
        elif len(postData['updated_title']) < 2:
            errors["updated_title"] = "The title should be at least 2 characters long!"
        # elif len(Show.objects.filter(title=postData['updated_title'])) > 0:
        #     errors['updated_title'] = "You cannot create a duplicate entry with this information."
        if len(postData['updated_network']) < 3:
            errors["updated_network"] = "The network name should be at least 3 characters long!"
        if len(postData['updated_desc']) > 0 and len(postData['updated_desc']) < 10:
            errors["updated_desc"] = "The description should be at least 10 characters long, if a description is to be entered!"
        if parse_date(postData['updated_release_date']) > date.today():
            errors['updated_release_date'] = "Must enter a past date for the release date!"
        return errors


class Show(models.Model):
    title = models.CharField(max_length = 255, unique = True)
    bound_network = models.CharField(max_length = 255)
    release_date = models.DateField()
    desc = models.TextField()
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)

    objects = ShowManager()

# class Network(models.Model):
#     name = models.CharField(max_length = 255)
#     shows = models.ManyToManyField(Show, related_name = "network")
#     created_at = models.DateTimeField(auto_now_add = True)
#     updated_at = models.DateTimeField(auto_now = True)