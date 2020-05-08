from django.shortcuts import render, redirect

def index(request):
    return render(request, 'index.html')
    
def result(request):
    name_from_form = request.POST['name'],
    dojo_location_from_form = request.POST['dojo-location'],
    fav_lang_from_form = request.POST['fav-lang'],
    comment_from_form = request.POST['comment'],
    context ={
        'name' : name_from_form,
        'dojoLocation' : dojo_location_from_form,
        'favLanguage' : fav_lang_from_form,
        'comment' : comment_from_form,
    }
    return render(request, 'result.html', context)

def goBack(request):
    return redirect('/')