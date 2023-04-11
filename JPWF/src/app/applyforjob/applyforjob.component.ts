import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Applyforjob } from '../applyforjob';
import { Services } from '../services';

@Component({
  selector: 'app-applyforjob',
  templateUrl: './applyforjob.component.html',
  styleUrls: ['./applyforjob.component.css']
})
export class ApplyforjobComponent {
  formValue!:FormGroup;
constructor(private  service:Services,private formBuilder:FormBuilder,private router:Router){}
jobApply:Applyforjob=new Applyforjob();
ngOnInit():void{
  this.formValue=this.formBuilder.group({
    jobSeekerId: ['',[Validators.required]],
    jobId: ['',[Validators.required]],
    resume: ['',[Validators.required]],
  })
}
applyforjob(){
this.jobApply.jobSeekerId=this.formValue.value.jobSeekerId;
this.jobApply.jobId=this.formValue.value.jobId;
this.jobApply.resume=this.formValue.value.resume;

  this.service.applyforjob(this.jobApply).subscribe({
next:(res)=>{
  console.log(res);
  alert("Applied Successfully");
  this.router.navigate(['/welcomejobseeker']);
  let ref=document.getElementById('cancel')
  ref?.click();
  this.formValue.reset();
},
error:()=>{
  alert("Not Assigned the value");
}
  })
}
onSubmit()
{
  this.router.navigate(['/welcomejobseeker']);
}

}
