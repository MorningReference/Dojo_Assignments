# Generated by Django 2.2.4 on 2020-05-15 20:50

from django.db import migrations


class Migration(migrations.Migration):

    dependencies = [
        ('TV_shows_app', '0003_show_bound_network'),
    ]

    operations = [
        migrations.DeleteModel(
            name='Network',
        ),
    ]