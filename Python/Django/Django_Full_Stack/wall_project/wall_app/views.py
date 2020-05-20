from django.shortcuts import render, redirect
from django.contrib import messages
from .models import Messages, Comments
from login_registration_app.models import User
from datetime import datetime

def wall(request):
    if 'userId' not in request.session:
        return redirect('/')
    elif 'userId' in request.session:
        context = {
            'userName': User.objects.get(id = request.session['userId']).first_name,
            'all_the_messages_sorted': reversed(Messages.objects.all()),
            'userId': request.session['userId'],
        }
        return render(request, 'wall.html', context)

def postMessage(request):
    Messages.objects.create(
        message = request.POST['message'],
        user = User.objects.get(id = request.session['userId'])
    )
    return redirect('/wall')

def postComment(request, messageId):
    Comments.objects.create(
        message = Messages.objects.get(id = messageId),
        user = User.objects.get(id = request.session['userId']),
        comment = request.POST['comment'],

    )
    return redirect('/wall')

def deletePost(request, messageId):
    errors = Messages.objects.message_validation(request.POST)
    
    if len(errors) > 0:
        for key, value in errors.items():
            messages.error(request, value, extra_tags = key)
        return redirect('/wall')
    else:
        Messages.objects.get(id = messageId).delete()
        return redirect('/wall')

def logout(request):
    request.session.flush()
    return redirect('/')