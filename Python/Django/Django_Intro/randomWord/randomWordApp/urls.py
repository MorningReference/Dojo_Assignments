from django.urls import path
from . import views

urlpatterns = [
    path('/', views.index),
    path('/generateWord', views.generateWord),
    path('/success', views.success),
    path('/reset', views.reset),
]