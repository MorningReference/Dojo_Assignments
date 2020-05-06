from django.shortcuts import render
from time import gmtime, strftime
import datetime

def index(request):
    context = {
        "time": strftime("%b %d, %Y %I:%M %p", gmtime()),
        "datetime": datetime.datetime.now()
    }
    return render(request,'index.html', context)