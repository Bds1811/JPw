import { map, Observable } from "rxjs";
import{HttpClient}from'@angular/common/http';
import { Injectable } from "@angular/core";
import { Jobseekerdetails } from "./jobseekerdetails";
@Injectable({
  providedIn: 'root'
})

export class Services {

    getProfileData() {
        throw new Error('Method not implemented.');
      }
    
      constructor(private http:HttpClient) { }
    
      getJobSeekerData()
      {
        return this.http.get<any>("http://localhost:5189/api/JobSeekers").pipe(map((res:any)=>{return res;}))
      }
      getCompanyDetailsData()
      {
        return this.http.get<any>("http://localhost:5189/api/Companies").pipe(map((res:any)=>{return res;}))
      }
      getJobListData()
      {
        return this.http.get<any>("http://localhost:5189/api/JobPostings").pipe(map((res:any)=>{return res;}))
      }
      getJobOpeningsData()
      {
        return this.http.get<any>("http://localhost:5189/api/JobPostings").pipe(map((res:any)=>{return res;}))
      }
      postJob(data:any)
      {
        return this.http.post<any>("http://localhost:5189/api/JobPostings",data).pipe(map((res:any)=>{return res;}))
      }
    postJobSeeker(data:any)
    {
      return this.http.post<any>("http://localhost:5189/api/JobSeekers",data).pipe(map((res:any)=>{return res;}))
    
    }
    applyforjob(data:any){
    
      return this.http.post<any>("http://localhost:5189/api/ApplyforJobs",data).pipe(map((res:any)=>{return res;}))
    
    }
    
    
    getApplicantslistData()
      {
        return this.http.get<any>("http://localhost:5189/api/JobSeekers").pipe(map((res:any)=>{return res;}))
      }
      
    getJobseekerProfileData(){
    
      return this.http.get<any>("http://localhost:5189/api/JobSeekers").pipe(map((res:any)=>{return res;}))
    
    }
    deletedetails(companyId:string)
      {
        return this.http.delete<any>("http://localhost:5189/api/Companies"+companyId).pipe(map((res:any)=>{return res;}))
      }
}
