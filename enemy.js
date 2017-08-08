var player_object : Transform;
function update (){
	GetComponent.<Renderer>().material.color = Color.red;
	transform.LookAt(player_object.transfrom);
	transform.translate(Vector3(0,0,0.08));
}