from django.shortcuts import render, redirect
import random, datetime

def index(request):
    if 'gold' not in request.session:
        request.session['gold'] = 0
    if 'move' not in request.session:
        request.session['move'] = 0
    if 'win' not in request.session:
        request.session['win'] = False
    if 'lose' not in request.session:
        request.session['lose'] = False
    if 'activities' not in request.session:
        request.session['activities'] = []
    if 'win_gold' not in request.session:
        request.session['win_gold'] = 9999
    if 'win_turn' not in request.session:
        request.session['win_turn'] = 9999

        
    request.session['farmRandom'] = random.randint(10, 20)
    request.session['caveRandom'] = random.randint(5, 10)
    request.session['houseRandom'] = random.randint(2, 5)
    request.session['casinoRandom'] = random.randint(-50, 50)
    return render(request, 'index.html')

def process(request, place):
    if 'gold' not in request.session:
        request.session['gold'] = 0
    if 'move' not in request.session:
        request.session['move'] = 0
    if 'win' not in request.session:
        request.session['win'] = False
    if 'lose' not in request.session:
        request.session['lose'] = False
    if 'activities' not in request.session:
        request.session['activities'] = []

    request.session['move'] += 1
    print(request.session['activities'])
    if not request.session['win'] and not request.session['lose']:
        if place == 'farm':
            request.session['gold'] += request.session['farmRandom']
            request.session['activities'].append(f"Earned {request.session['farmRandom']} from the {place}! ({datetime.datetime.now()})")
        elif place == 'cave':
            request.session['gold'] += request.session['caveRandom']
            request.session['activities'].append(f"Earned {request.session['caveRandom']} from the {place}! ({datetime.datetime.now()})")
        elif place == 'house':
            request.session['gold'] += request.session['houseRandom']
            request.session['activities'].append(f"Earned {request.session['houseRandom']} from the {place}! ({datetime.datetime.now()})")
        elif place == 'casino':
            request.session['gold'] += request.session['casinoRandom']
            request.session['activities'].append(f"Earned {request.session['casinoRandom']} from the {place}! ({datetime.datetime.now()})")
        if request.session['gold'] < 0:
            request.session['lose'] = True
            request.session['activities'].append('You lose!')
        if request.session['gold'] >= int(request.session['win_gold']) and request.session['move'] <= int(request.session['win_turn']):
            request.session['win'] = True
            request.session['activities'].append('You win!')
        elif request.session['gold'] < int(request.session['win_gold']) and request.session['move'] >= int(request.session['win_turn']):
            request.session['lose'] = True
            request.session['activities'].append('You lose!')


    return redirect('/')


def setWinCondition(request):
    request.session['win_turn'] = request.POST['win_turn']
    request.session['win_gold'] = request.POST['win_gold']
    request.session['activities'].append(f"Win conditions set! Numbers of turns to win by: {request.session['win_turn']} Amount of gold to have: {request.session['win_gold']}! ({datetime.datetime.now()})")
    
    return redirect('/')

def restart(request):
    request.session.clear()  #set sessions to empty
    # request.session['activities'].append("Session was cleared")

    return redirect('/')