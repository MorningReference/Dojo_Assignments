# Generated by Django 2.2.4 on 2020-05-21 19:02

from django.db import migrations


class Migration(migrations.Migration):

    dependencies = [
        ('loginApp', '0002_user_birthdate'),
    ]

    operations = [
        migrations.RenameField(
            model_name='user',
            old_name='last_name',
            new_name='alias',
        ),
        migrations.RenameField(
            model_name='user',
            old_name='first_name',
            new_name='name',
        ),
    ]
