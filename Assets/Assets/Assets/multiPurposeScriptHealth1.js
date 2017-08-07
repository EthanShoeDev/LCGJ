
static var curHp : float = 300.0;
static var maxHp : float = 300.0;
static var curMana : float = 70.0;
static var maxMana : float = 70.0;
var HpBarTexture : Texture2D;
var ManaBarTexture : Texture2D;
var hpBarLength : float;
var percentOfHp : float;
var manaBarLength : float;
var percentOfMana :float;
 
 
function OnGUI () {
 
    if (curHp > 0) {
            GUI.DrawTexture(Rect((Screen.width/2) - 100, 10, hpBarLength, 10), HpBarTexture);
        }
        if (curMana > 0) {
            GUI.DrawTexture(Rect((Screen.width/2) - 100, 20, manaBarLength, 10), ManaBarTexture);
        }
}
 
function Update () {
 
    percentOfHP = curHp/maxHp;
    hpBarLength = percentOfHP*100;
 
    percentOfMana = curMana/maxMana;
    manaBarLength = percentOfMana*100;
 
    if(Input.GetKeyDown("q")) {
        curHp -= 10.0;
    }
 
    if(Input.GetKeyDown("m")) {
        curMana -= 10.0;
    }
}

function death  () {
if (curHp == 0);
	Destroy (this.gameObject);

}
//function ManaLoss(){

	//if (curMana == 0);
	//curMana = 


//}
//function  update (){

//if (Input.GetKeyDown("x")) {
    
//}