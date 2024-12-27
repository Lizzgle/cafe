import { Component, OnInit } from '@angular/core';

import { ActivatedRoute } from '@angular/router';

import { UserService } from '../../../core/services/user.service';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrl: './user-detail.component.css'
})
export class UserDetailComponent implements OnInit {
  userId: string = '';
  user: any = {};

  constructor(
    private route: ActivatedRoute,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    this.userId = this.route.snapshot.paramMap.get('id')!;
    this.userService.getUserById(this.userId).subscribe(data => {
      this.user = data;
    });
  }
}
