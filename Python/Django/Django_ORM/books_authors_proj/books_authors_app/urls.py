from django.urls import path
from . import views

urlpatterns = [
    path('', views.create_books),
    path('authors', views.create_authors),
    path('process_book', views.process_book),
    path('process_author', views.process_author),
    path('books/<book_id>', views.display_book),
    path('authors/<author_id>', views.display_author),
    path('books/<book_id>/add_author', views.add_author),
    path('authors/<author_id>/add_book', views.add_book),
]