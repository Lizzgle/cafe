import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class UserService {
    private apiUrl = 'https://localhost:7111/api/users';

    constructor(private http: HttpClient) {}

    getUsers(): Observable<any> {
        return this.http.get<[]>(this.apiUrl);
    }
    
    getUserById(id: string): Observable<any> {
        return this.http.get<[]>(`${this.apiUrl}/${id}`);
    }

    getMeUserById(): Observable<any> {
        return this.http.get<[]>(`${this.apiUrl}/me`);
    }
    
    updateUser(user: any): Observable<any> {
        return this.http.put<[]>(`${this.apiUrl}/${user.id}`, user);
    }

    deleteUser(id: string): Observable<any> {
        return this.http.delete<[]>(`${this.apiUrl}/${id}`);
    }
    
}