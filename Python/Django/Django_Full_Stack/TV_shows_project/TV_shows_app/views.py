from django.shortcuts import render, redirect
from django.contrib import messages

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
    print("form data", request.POST)

    errors = Show.objects.add_show_validator(request.POST)

    if len(errors) > 0:
        for key, value in errors.items():
            messages.error(request, value, extra_tags=key)
        return redirect('/shows/new')

    else:
        new_show = Show.objects.create(
            title = request.POST['show_title'],
            bound_network = request.POST['show_network'],
            release_date = request.POST['show_release_date'],
            desc = request.POST['show_desc']
        )
        return redirect(f'/shows/{new_show.id}')

def show_show(request, id):
    context = {
        "show": Show.objects.get(id = id)
    }
    return render(request, 'show_display.html', context)

def edit_show(request, id):
    context = {
        "show": Show.objects.get(id = id),
    }
    return render(request, 'show_edit.html', context)

def update_show(request, id):

    errors = Show.objects.edit_show_validator(request.POST)

    if len(errors) > 0:
        for key, value in errors.items():
            messages.error(request, value, extra_tags=key)
        return redirect(f'/shows/{id}/edit')

    else:
        updated_show = Show.objects.get(id = id)
        updated_show.title = request.POST['updated_title']
        updated_show.bound_network = request.POST['updated_network']
        updated_show.release_date = request.POST['updated_release_date']
        updated_show.desc = request.POST['updated_desc']
        updated_show.save()
        return redirect(f'/shows/{id}')

def destroy_show(request, id):
    Show.objects.get(id = id).delete()
    return redirect('/shows')
