import { UserLogin } from "./userLogin";

export interface User extends UserLogin{
    email:string,
    name:string,
    surname:string,
    role:string,
    token:string,
}