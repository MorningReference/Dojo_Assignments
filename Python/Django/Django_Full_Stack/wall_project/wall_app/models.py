from django.db import models
from login_registration_app.models import User
from datetime import datetime, timedelta
from django.utils import timezone


class MessageManager(models.Manager):
    def message_validation(self, postData):
        errors = {}
        timeLimit = timezone.now() - timedelta(minutes = 30)
        print((Messages.objects.filter(id = postData['messageId'])[0].created_at - timezone.now()), timedelta(minutes = 30))
        # if Messages.objects.filter(id = postData['messageId'])[0].created_at < timeLimit:
        #     errors['messageId'] = "Time limit to delete the comment has been exceeded!"
        if Messages.objects.filter(id = postData['messageId'])[0].created_at < timeLimit:
            errors[postData['messageId']] = "Time limit to delete the comment has been exceeded!"
            print(f"Error message created for {postData['messageId']}")
            print(errors[postData['messageId']])
        return errors

class Messages(models.Model):
    message = models.TextField()
    user = models.ForeignKey(User, related_name = "messages", on_delete = models.CASCADE)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    objects = MessageManager()

class Comments(models.Model):
    message = models.ForeignKey(Messages, related_name = "comments", on_delete = models.CASCADE)
    user = models.ForeignKey(User, related_name = "comments", on_delete = models.CASCADE)
    comment = models.TextField()
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)