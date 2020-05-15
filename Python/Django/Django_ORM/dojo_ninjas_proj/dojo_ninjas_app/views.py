from django.shortcuts import render, redirect
from .models import dojos, ninjas

def index(request):
    context = {
        "all_the_dojos": dojos.objects.all(),
        "all_the_ninjas": ninjas.objects.all()
    }
    return render(request, 'index.html', context)


def process(request, type):
    if type == 'dojo':
        dojos.objects.create(
            name = request.POST['dojo-name'],
            city = request.POST['dojo-city'],
            state = request.POST['dojo-state']
        )
    elif type == 'ninja':
        ninjas.objects.create(
            dojo_id = dojos.objects.get(name = request.POST['ninja-dojo']),
            first_name = request.POST['ninja-first-name'],
            last_name = request.POST['ninja-last-name']
        )

    return redirect('/')

def deleteDojo(request, dojo):
    dojos.objects.get(name = dojo).delete()
    return redirect('/')