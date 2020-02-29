export class JsonWebToken{
    id: string
    accessToken:string;
    refreshToken:string;
    expires:number; 
    claims: {
        name:string;
        email:string;
    };
}