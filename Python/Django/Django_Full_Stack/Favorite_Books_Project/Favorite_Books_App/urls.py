from django.urls import path
from . import views

urlpatterns = [
    path('', views.book),
    path('addBook', views.addBook),
    path('<int:bookId>', views.displayBook),
    path('<int:bookId>/edit', views.editBook),
    path('<int:bookId>/like', views.likeBook),
    path('<int:bookId>/unlike', views.unlikeBook),
    path('<int:bookId>/delete', views.deleteBook),
    path('favoriteBooks', views.favoriteBooks)
    path('logout', views.logout)
]