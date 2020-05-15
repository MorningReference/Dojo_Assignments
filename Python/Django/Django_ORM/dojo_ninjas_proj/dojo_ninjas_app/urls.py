from django.urls import path
from . import views

urlpatterns = [
    path('', views.index),
    path('process/<type>', views.process),
    path('deleteDojo/<dojo>', views.deleteDojo)
]