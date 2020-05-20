from django.urls import path
from . import views

urlpatterns = [
    path('', views.wall),
    path('post_message', views.postMessage),
    path('post_comment/<int:messageId>', views.postComment),
    path('delete_message/<int:messageId>', views.deletePost),
    path('logout', views.logout),
]