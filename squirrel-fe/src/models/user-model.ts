export interface LoginModel{
    loginId: string,
    password: string,
    rememberMe: boolean,
  }
  
 export  interface UserInfoModel{
    name:string,
    blance:Number,
    userId:Number
  }
  
 export  interface LoginResponseModel{
    userInfo: UserInfoModel,
    email: string,
    token: string,
    expiration: string,
    roles: string[]
  }