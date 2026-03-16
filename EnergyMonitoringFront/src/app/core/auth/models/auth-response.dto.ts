export interface AuthResponseDto {
    token: string;
    expiration: string;
    userId: string;
    email: string;
    name: string;
}