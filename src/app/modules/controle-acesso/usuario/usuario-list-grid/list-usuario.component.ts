import { Component, OnInit, Input, TemplateRef } from '@angular/core';
import { UserService } from '../../usuario/user.service';
import { first } from 'rxjs/operators';
import { User } from 'src/app/models/user';
import DataSource from 'devextreme/data/data_source';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-list-usuario',
  templateUrl: './list-usuario.component.html',
  styles: ['./list-usuario.component.html']
})
export class ListUsuarioComponent implements OnInit {
  dataSource: DataSource;
  users: User[];


  constructor(   private userService: UserService,    private toastr: ToastrService) {

   }

  ngOnInit() {


    this.loadAllUsers();

    this.userService.userChanged.subscribe(
      (observable: any) => observable.subscribe(
        data => {this.users = data;
          this.dataSource = data;

        }
      )
    );


  }


 loadAllUsers() {
    this.userService.getAll().pipe(first()).subscribe(users => {
        this.users = users;
        this.dataSource  = new DataSource(this.users);
    });
}

deleteUser(id: number) {
  this.userService.delete(id).pipe(first()).subscribe(() => {
      this.loadAllUsers();
  });
}


}
