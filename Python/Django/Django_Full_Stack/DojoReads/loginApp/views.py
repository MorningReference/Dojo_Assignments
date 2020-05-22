from django.shortcuts import render, redirect
from .models import *
from readsApp.models import *
from django.contrib import messages
import bcrypt

def index(request):
    return render(request, 'index.html')

def register(request):
    if request.method == "GET":
        return redirect('/')

    errors = User.objects.registration_validation(request.POST)

    if len(errors) > 0:
        for key, value in errors.items():
            messages.error(request, value, extra_tags = key)
        return redirect('/')
    pw_hash = bcrypt.hashpw(request.POST['password'].encode(), bcrypt.gensalt()).decode()
    new_user = User.objects.create(
        name = request.POST['name'],
        alias = request.POST['alias'],
        email = request.POST['email'],
        birthdate = request.POST['birthdate'],
        password = pw_hash
    )
    request.session['user_id'] = new_user.id
    return redirect('/books')

def login(request):
    if request.method == "GET":
        return redirect('/')

    user = User.objects.filter(email = request.POST['login_email'])
    if user:
        if bcrypt.checkpw(request.POST['login_pw'].encode(), user[0].password.encode()):
            request.session['user_id'] = user[0].id
            return redirect('/books')

    messages.error(request, "Invalid email/password", extra_tags="login_email")
    return redirect('/')

def showUser(request, userId):
    context = {
        'user': User.objects.filter(id = userId)[0],
        'all_books_reviewed': Book.objects.filter(reviews__user_reviewed__id = userId).distinct()
    }
    return render(request, 'showUser.html', context)

def logout(request):
    request.session.flush()
    return redirect('/')
