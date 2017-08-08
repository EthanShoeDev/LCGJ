var end : Transform;


function update (){
	transform.LookAt(end.transfrom);
	transform.Translate(Vector3(0,0,0.03));
}

function OnCollisionEnter(collision : Collision){
	if (collision.gameObject.name == "END"){
		 Destroy(this.gameObject);

	}
}