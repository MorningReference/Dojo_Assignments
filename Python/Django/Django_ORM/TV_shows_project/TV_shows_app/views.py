from django.shortcuts import render, redirect
from .models import Show

def index(request):
    context = {
        "all_the_shows": Show.objects.all()
    }
    return render(request, 'index.html', context)

def new_show(request):
    # context = {
    #     # "all_the_networks": Network.objects.all()
    # }
    return render(request, 'new_show.html')

def create_show(request):
    new_show = Show.objects.create(
        title = request.POST['show_title'],
        bound_network = request.POST['show_network'],
        release_date = request.POST['release_date'],
        desc = request.POST['show_desc']
    )
    # new_show.network.add(Network.objects.get(id = request.POST['network_id']))

    return redirect(f'/shows/{new_show.id}')

def show_show(request, id):
    context = {
        "show": Show.objects.get(id = id)
    }
    return render(request, 'show_display.html', context)

def edit_show(request, id):
    context = {
        "show": Show.objects.get(id = id),
        # "all_the_networks": Network.objects.all()
    }
    return render(request, 'show_edit.html', context)

def update_show(request, id):
    updated_show = Show.objects.get(id = id)
    updated_show.title = request.POST['updated_title']
    updated_show.bound_network = request.POST['updated_network']
    # updated_show.network = Network.objects.get(id = request.POST['updated_network_id'])
    updated_show.release_date = request.POST['updated_release']
    updated_show.desc = request.POST['updated_desc']
    updated_show.save()
    return redirect(f'/{id}')

def destroy_show(request, id):
    Show.objects.get(id = id).delete()
    return redirect('/shows')