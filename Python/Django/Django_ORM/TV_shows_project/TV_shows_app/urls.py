from django.urls import path
from . import views

urlpatterns = [
    path('', views.index),
    path('new', views.new_show),
    path('new/create', views.create_show),
    path('<int:id>', views.show_show),
    path('<int:id>/edit', views.edit_show),
    path('<int:id>/update', views.update_show),
    path('<int:id>/destroy', views.destroy_show),
]