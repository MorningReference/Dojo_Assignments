from django.shortcuts import render, redirect
from django.contrib import messages
from .models import *
import bcrypt

def index(request):
    return render(request, 'index.html')

def register(request):
    errors = User.objects.user_registration_validator(request.POST)

    if len(errors) > 0:
        for key, value in errors.items():
            messages.error(request, value, extra_tags = key)
        return redirect('/')
    else:
        password = request.POST['passwordReg']
        pw_hash = bcrypt.hashpw(password.encode(), bcrypt.gensalt()).decode()

        confirmPassword = request.POST['confirmPasswordReg']
        confirmPw_hash = bcrypt.hashpw(password.encode(), bcrypt.gensalt()).decode()

        user = User.objects.create(
            first_name = request.POST['firstNameReg'],
            last_name = request.POST['lastNameReg'],
            email = request.POST['emailReg'],
            birth_date = request.POST['birthdayReg'],
            password = pw_hash,
            confirm_password = confirmPw_hash
        )
        request.session['userId'] = user.id
        return redirect('/books')

def login(request):
    errors = User.objects.user_login_validator(request.POST)

    if len(errors) > 0:
        for key, value in errors.items():
            messages.error(request, value, extra_tags = key)
        return redirect('/')
    else:
        request.session['userId'] = User.objects.filter(email = request.POST['emailLogin'])[0].id
        return redirect('/books')

# def success(request):
#     if 'userName' not in request.session:
#         return redirect('/')
#     elif 'userName' in request.session:
#         context = {
#             'userName': User.objects.get(id = request.session['userId'])
#         }
#         return render(request, 'success.html', context)
        

# def logout(request):
#     request.session.flush()
#     return redirect('/')

