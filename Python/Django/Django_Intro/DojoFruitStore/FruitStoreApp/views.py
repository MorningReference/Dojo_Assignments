from django.shortcuts import render
import datetime

def index(request):
    return render(request,"index.html")

def checkout(request):
    name_from_form = request.POST['name']
    studentId_from_form = request.POST['student-id']
    strawberryAmt_from_form = request.POST['strawberryAmt']
    raspberryAmt_from_form = request.POST['raspberryAmt']
    appleAmt_from_form = request.POST['appleAmt']

    context = {
        'name' : name_from_form,
        'studentId' : studentId_from_form,
        'strawberryAmt' : strawberryAmt_from_form,
        'raspberryAmt' : raspberryAmt_from_form,
        'appleAmt' : appleAmt_from_form,
        'totalFruitAmt' : int(strawberryAmt_from_form) + int(raspberryAmt_from_form) + int(appleAmt_from_form),
        'datetime' : datetime.datetime.now()
    }
    print("Charging {{name}} for {{totalFruitAmt}} fruits")
    return render(request, "checkout.html", context)