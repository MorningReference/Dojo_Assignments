from django.shortcuts import render, redirect
from django.utils.crypto import get_random_string

def index(request):
    request.session['counter'] = 0
    rand_word_from_session = get_random_string(length=14)
    context = {
        'counter' : request.session['counter'],
        'randomWord': rand_word_from_session
    }
    return render(request, 'index.html', context)

def generateWord(request):
    request.session['counter'] += 1
    return redirect('/random_word/success')

def success(request):
    counter_from_session = request.session['counter']
    rand_word_from_session = get_random_string(length=14)
    context = {
        'counter': counter_from_session,
        'randomWord': rand_word_from_session
    }
    return render(request, 'success.html', context)

def reset(request):
    return redirect('/random_word')
