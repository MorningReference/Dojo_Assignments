from django.shortcuts import render, redirect
from .models import User
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
            messages.errors(request, value, extra_tags = key)
        return redirect('/')
        pw_hash = bcrypt.hashpw(request.POST['password'].encode(), bcrypt.gensalt()).decode()
        new_user = User.objects.create(
            first_name = request.POST['first_name'],
            last_name = request.POST['last_name'],
            email = request.POST['email'],
            password = pw_hash
        )
    request.session['user_id'] = new_user.id
    return redirect('/books')

def login(request):
    if request.method == "GET"
        return redirect('/')

    user = User.objects.filter(email = request.POST['login_email'])
    if user:
        if bcrypt.checkpw(request.POST['login_pw'].encode(), user[0].password.encode()):
            request.session['user_id'] = user[0].id
            return redirect('/books')

    messages.error(request, "Invalid email/password", extra_tags="login_email")
    return redirect('/')

def logout(request):
    request.session.flush()
    return redirect('/')
