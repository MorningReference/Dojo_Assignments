from django.urls import path
from . import views

urlpatterns =[
    path('', views.index),
    path('process_money/<str:place>', views.process),
    path('set_win_condition', views.setWinCondition),
    path('refresh', views.restart),

]