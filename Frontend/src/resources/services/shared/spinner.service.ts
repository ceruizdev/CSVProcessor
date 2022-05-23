import { Injectable } from "@angular/core";
import { BehaviorSubject, Subject } from "rxjs";

@Injectable(
    {providedIn:'root'} 
)
export class SpinnerService{
    isLoading$ = new BehaviorSubject<boolean>(false);
    show(){
        this.isLoading$.next(true);
    }
    Hide(){
        this.isLoading$.next(false);
    }
}