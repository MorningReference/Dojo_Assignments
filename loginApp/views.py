from django.shortcuts import render, redirect
from .models import *
from beltApp.models import *

from django.contrib import messages
import bcrypt

def index(request):
    # If the user is already logged in, they cannot navigate to the login/registration page
    if 'user_id' in request.session:
        return redirect('/quotes') #Change this to route to the index of our productApp
    return render(request, 'index.html')

def register(request):
    # Redirect users who navigate to this page without sending a form
    if request.method == "GET":
        return redirect('/')
    
    errors = User.objects.registration_validation(request.POST)

    if len(errors) > 0:
        for key, value in errors.items():
            messages.error(request, value, extra_tags = key)
        return redirect('/')
    pw_hash = bcrypt.hashpw(request.POST['password'].encode(), bcrypt.gensalt()).decode()
    new_user = User.objects.create(
        first_name = request.POST['first_name'],
        last_name = request.POST['last_name'],
        email = request.POST['email'],
        password = pw_hash
    )
    request.session['user_id'] = new_user.id
    return redirect('/quotes') #Change this to route to the index of our productApp

def login(request):
    # Redirect users who navigate to this page without sending a form
    if request.method == "GET":
        return redirect('/')

    user = User.objects.filter(email = request.POST['login_email'])
    if user:
        if bcrypt.checkpw(request.POST['login_pw'].encode(), user[0].password.encode()):
            request.session['user_id'] = user[0].id
            return redirect('/quotes')

    messages.error(request, "Invalid email/password", extra_tags="login_email")
    return redirect('/')

# def editUser(request, userId):
#     if 'user_id' not in request.session:
#         return redirect('/')
#     if request.method == "GET":
#         if request.session['user_id'] != userId:
#             return redirect('/quotes')

#     context = {
#         'user': User.objects.filter(id = request.session['user_id'])[0]
#     }
#     return render(request, 'editUser.html', context)

# def updateUser(request, userId):
#     if 'user_id' not in request.session:
#         return redirect('/')
#     if request.method == "GET":
#         return redirect(f'/myaccounts/{userId}')
#     if request.session['user_id'] != userId:
#             return redirect('/quotes')

#     errors = User.objects.update_validation(request.POST)

#     if len(errors) > 0:
#         for key, value in errors.items():
#             messages.error(request, value, extra_tags = key)
#         return redirect(f'/myaccount/{userId}')
    
#     user = User.objects.filter(id = request.session['user_id'])[0]
#     user.first_name = request.POST['updated_first_name']
#     user.last_name = request.POST['updated_last_name']
#     user.email = request.POST['updated_email']
#     user.save()
#     return redirect(f'/myaccount/{userId}')

def logout(request):
    request.session.flush()
    return redirect('/')
