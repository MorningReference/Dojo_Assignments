from django.urls import path
from . import views

urlpatterns =[
    path('', views.index),
    path('add', views.newBook),
    path('create', views.createBook),
    path('<int:bookId>', views.showBook),
    path('<int:bookId>/review', views.createReview),
    path('<int:bookId>/deleteReview/<int:reviewId>', views.deleteReview)
]